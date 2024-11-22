import { LitElement, html, customElement, property } from "@umbraco-cms/backoffice/external/lit";
import type { UmbPropertyEditorUiElement } from '@umbraco-cms/backoffice/extension-registry';
import { UmbChangeEvent } from '@umbraco-cms/backoffice/event';
import './dawoe-input-oembed';
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import { UmbEmbeddedMediaModalValue } from "@umbraco-cms/backoffice/modal"
import { UmbPropertyValueChangeEvent } from "@umbraco-cms/backoffice/property-editor";

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

	@property({ type: Array<UmbEmbeddedMediaModalValue> })
	public set value(selectionString: Array<UmbEmbeddedMediaModalValue> | undefined) {
		this.#selection = selectionString ?? [];
	}
	public get value(): Array<UmbEmbeddedMediaModalValue> | undefined {
		return this.#selection;
	}

	#onChange(event: CustomEvent & { target: { selection: UmbEmbeddedMediaModalValue[] | undefined } }) {
		this.#selection = event.target.selection ?? [];
		this.value = this.#selection;
		console.log("selection", this.#selection);
		console.log("value", this.value);
		this.dispatchEvent(new UmbPropertyValueChangeEvent());
	}

	#selection: Array<UmbEmbeddedMediaModalValue> = [];

	render() {
		return html`<pre>${JSON.stringify(this.value)}</pre> 
		<dawoe-input-ombed 
			.selection=${this.#selection} 
			?readonly=${this.readonly}
			@change=${this.#onChange}>
		</dawoe-input-ombed> 
		test test test`;
	}
}

declare global {
	interface HTMLElementTagNameMap {
		'dawaoe-oembed-picker': DawoeOembedPicker;
	}
}
