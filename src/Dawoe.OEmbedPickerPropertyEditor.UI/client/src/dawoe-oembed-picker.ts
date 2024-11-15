import { LitElement, html, customElement, property } from "@umbraco-cms/backoffice/external/lit";
import type { UmbPropertyEditorUiElement } from '@umbraco-cms/backoffice/extension-registry';

@customElement('dawaoe-oembed-picker')
export default class DawoeOembedPicker extends LitElement implements UmbPropertyEditorUiElement {
  @property({ type: String })
  public value = "";

  render() {
    return html`I'm a property editor!`;
  }
}

declare global {
  interface HTMLElementTagNameMap {
    'dawaoe-oembed-picker': DawoeOembedPicker;
  }
}
