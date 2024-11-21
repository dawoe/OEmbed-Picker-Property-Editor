import { LitElement, html, customElement, property } from "@umbraco-cms/backoffice/external/lit";
import type { UmbPropertyEditorUiElement } from '@umbraco-cms/backoffice/extension-registry';
import { UmbChangeEvent } from '@umbraco-cms/backoffice/event';
import './dawoe-input-oembed';
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import { UmbEmbeddedMediaModalValue } from "@umbraco-cms/backoffice/modal"

@customElement('dawaoe-oembed-picker')
export default class DawoeOembedPicker extends UmbLitElement implements UmbPropertyEditorUiElement {
	/**
		 * Sets the input to readonly mode, meaning value cannot be changed but still able to read and select its content.
		 * @type {boolean}
		 * @attr
		 * @default false
		 */
	@property({ type: Boolean, reflect: true })
	readonly = false;

	@property({ type: Array })
	public set selection(values: Array<UmbEmbeddedMediaModalValue>) {
		this.#selection = values ?? [];
	}
	public get selection(): Array<UmbEmbeddedMediaModalValue> {
		return this.#selection;
	}

	@property({ type: String })
	public set value(selectionString: string | undefined) {
		this.#selection = selectionString ? JSON.parse(selectionString) : [];
	}
	public get value(): string | undefined {
		return this.#selection.length > 0 ? this.#selection.join(',') : undefined;
	}

	#onChange(event: CustomEvent & { target: { selection: UmbEmbeddedMediaModalValue[] | undefined } }) {
		this.#selection = event.target.selection ?? [];
		this.value = JSON.stringify(this.#selection);
		this.dispatchEvent(new UmbChangeEvent());
	}

	#selection: Array<UmbEmbeddedMediaModalValue> = [];

	render() {
		return html`${JSON.stringify(this.value)} <dawoe-input-ombed 
													.selection=${this.#selection} 
													?readonly=${this.readonly}
													@change=${this.#onChange}>
										</dawoe-input-ombed> test test test`;
	}
}

declare global {
	interface HTMLElementTagNameMap {
		'dawaoe-oembed-picker': DawoeOembedPicker;
	}
}
