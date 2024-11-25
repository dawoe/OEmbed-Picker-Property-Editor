import { LitElement, html, customElement, property, state } from "@umbraco-cms/backoffice/external/lit";
import type { UmbPropertyEditorUiElement } from '@umbraco-cms/backoffice/extension-registry';
import './dawoe-input-oembed';
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import { UmbPropertyValueChangeEvent } from "@umbraco-cms/backoffice/property-editor";
import { type UmbPropertyEditorConfigCollection } from "@umbraco-cms/backoffice/property-editor";
import { OEmbedPickerValue } from "./oembedvalue";


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

	@state()
	private _allowMultiple?: boolean;

	@property({ attribute: false })
	public set config(config: UmbPropertyEditorConfigCollection) {
		this._allowMultiple = config.getValueByAlias("allowMultiple");
	}

	@property({ type: Array })
	public set selection(values: Array<OEmbedPickerValue>) {
		this.#selection = values ?? [];
	}
	public get selection(): Array<OEmbedPickerValue> {
		return this.#selection;
	}

	@property({ type: Array<OEmbedPickerValue> })
	public set value(selectionString: Array<OEmbedPickerValue> | undefined) {
		this.#selection = selectionString ?? [];
	}
	public get value(): Array<OEmbedPickerValue> | undefined {
		return this.#selection;
	}

	#onChange(event: CustomEvent & { target: { selection: OEmbedPickerValue[] | undefined } }) {
		this.#selection = event.target.selection ?? [];
		this.value = this.#selection;
		this.dispatchEvent(new UmbPropertyValueChangeEvent());
	}

	#selection: Array<OEmbedPickerValue> = [];

	render() {
		return html`
		<dawoe-input-ombed 
			.selection=${this.#selection} 
			?readonly=${this.readonly}
			.allowMultiple=${this._allowMultiple}
			@change=${this.#onChange}>
		</dawoe-input-ombed>`;
	}
}

declare global {
	interface HTMLElementTagNameMap {
		'dawaoe-oembed-picker': DawoeOembedPicker;
	}
}
