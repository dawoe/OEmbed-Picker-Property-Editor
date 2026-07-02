import {
	css,
	customElement,
	html,
	ifDefined,
	nothing,
	property,
	repeat,
	state,
	unsafeHTML,
} from '@umbraco-cms/backoffice/external/lit';
import { splitStringToArray } from '@umbraco-cms/backoffice/utils';
import { UmbChangeEvent } from '@umbraco-cms/backoffice/event';
import { UmbLitElement } from '@umbraco-cms/backoffice/lit-element';
import { UmbModalRouteRegistrationController } from '@umbraco-cms/backoffice/router';
import { UmbSorterController } from '@umbraco-cms/backoffice/sorter';
import { UmbFormControlMixin } from '@umbraco-cms/backoffice/validation';
import { UMB_EMBEDDED_MEDIA_MODAL, UmbEmbeddedMediaModalData } from '@umbraco-cms/backoffice/embedded-media';

import {
	UMB_MODAL_MANAGER_CONTEXT,
} from "@umbraco-cms/backoffice/modal";


import '@umbraco-cms/backoffice/imaging';
import { OEmbedPickerValue } from './oembedvalue';

const elementName = 'dawoe-input-ombed';
@customElement(elementName)
export class DawoeInputOmbedElement extends UmbFormControlMixin<string | undefined, typeof UmbLitElement>(UmbLitElement) {
	#sorter = new UmbSorterController<OEmbedPickerValue>(this, {
		getUniqueOfElement: (element) => {
			return element.getAttribute('detail');
		},
		getUniqueOfModel: (modelEntry) => {
			return modelEntry.url;
		},
		identifier: 'Dawoe.SorterIdentifier.InputOembed',
		itemSelector: 'uui-card-media',
		containerSelector: '.container',
		/** TODO: This component probably needs some grid-like logic for resolve placement... [LI] */
		resolvePlacement: () => false,
		onChange: ({ model }) => {
			this.selection = model;
			this.#sortCards(model);
			this.dispatchEvent(new UmbChangeEvent());
		},
	});

	#sortCards(model: Array<OEmbedPickerValue>) {
		const idToIndexMap: { [url: string]: number } = {};
		model.forEach((item, index) => {
			idToIndexMap[item.url] = index;
		});

		const cards = [...this._cards];
		this._cards = cards.sort((a, b) => idToIndexMap[a.url] - idToIndexMap[b.url]);
	}

	/**
	 * This is a maximum amount of selected items in this input.
	 * @type {boolean}
	 * @attr
	 * @default
	 */
	@property({ type: Boolean })
	allowMultiple: boolean | undefined = false;

	public set selection(ids: Array<OEmbedPickerValue>) {
		this._cards = ids;
		this.#sorter.setModel(this._cards);
	}
	public get selection(): Array<OEmbedPickerValue> {
		return this._cards;
	}

	@property({ type: String })
	public override set value(selectionString: string | undefined) {
		this.selection = selectionString ? JSON.parse(selectionString) : [];
	}
	public override get value(): string | undefined {
		return this.selection.length > 0 ? JSON.stringify(this.selection) : undefined;
	}

	/**
	 * Sets the input to readonly mode, meaning value cannot be changed but still able to read and select its content.
	 * @type {boolean}
	 * @attr
	 * @default
	 */
	@property({ type: Boolean, reflect: true })
	public get readonly() {
		return this.#readonly;
	}
	public set readonly(value) {
		this.#readonly = value;

		if (this.#readonly) {
			this.#sorter.disable();
		} else {
			this.#sorter.enable();
		}
	}
	#readonly = false;

	@state()
	private _cards: Array<OEmbedPickerValue> = [];

	#modalManagerContext?: typeof UMB_MODAL_MANAGER_CONTEXT.TYPE;

	constructor() {
		super();

		this.consumeContext(UMB_MODAL_MANAGER_CONTEXT, (instance) => {
			this.#modalManagerContext = instance;
			// modalManagerContext is now ready to be used.
		});
	}


	#openPicker() {
		const modalContext = this.#modalManagerContext?.open(this, UMB_EMBEDDED_MEDIA_MODAL);
		modalContext
			?.onSubmit()
			.then((value) => {				
				this._cards = [...this._cards, 
					{
						url: value.url,
						preview: value.markup,
						width: value.width,
						height: value.height
					}
				];
				this.#sorter.setModel(this._cards);
				this.dispatchEvent(new UmbChangeEvent());
			})
			.catch(() => undefined);
  }

  #openEditPicker(index:number) {
    let card = this._cards[index];
    let data: UmbEmbeddedMediaModalData = {
      url: card.url,
      height: card.height,
      width: card.width, 
    };
    const modalContext = this.#modalManagerContext?.open(this, UMB_EMBEDDED_MEDIA_MODAL, { data });
    
    modalContext
      ?.onSubmit()
      .then((value) => {
        let items = [...this._cards];

        items[index] = {
          url: value.url,
          preview: value.markup,
          width: value.width,
          height: value.height
        };
                       
        this._cards = [...items];
        
        this.#sorter.setModel(this._cards);
        this.dispatchEvent(new UmbChangeEvent());
      })
      .catch(() => undefined);
  }

	async #onRemove(index:number) {
		this._cards = this._cards.filter((_, i) => i !== index);
		this.#sorter.setModel(this._cards);
		this.dispatchEvent(new UmbChangeEvent());
  }

  async #onEdit(index: number) {
    this.#openEditPicker(index);
  }

	override render() {
		return html`<div class="container">${this.#renderItems()} ${this.#renderAddButton()}</div>`;
	}

	#renderItems() {
		if (!this._cards?.length) return nothing;
		return html`
			${repeat(
			this._cards,
			(item, index) => item.url,
			(item, index) => this.#renderItem(item, index),
		)}
		`;
	}

	#renderAddButton() {
		// TODO: Stop preventing adding more, instead implement proper validation for user feedback. [NL]
		//if (this._cards && this.max && this._cards.length >= this.max) return nothing;
		if ((this.readonly && this._cards.length > 0) || (!this.allowMultiple && this._cards.length > 0)) {
			return nothing;
		} else {
			return html`
				<uui-button
					id="btn-add"
					look="placeholder"
					@click=${this.#openPicker}
					label=${this.localize.term('general_choose')}
					?disabled=${this.readonly}>
					<uui-icon name="icon-add"></uui-icon>
					${this.localize.term('general_choose')}
				</uui-button>
			`;
		}
	}

	#renderItem(item: OEmbedPickerValue, index:number) {
		return html`
		<uui-card-media class="preview-item"
				name=${item.url}
				detail=${item.url}
				?readonly=${this.readonly}>
				${unsafeHTML(item.preview)}
				<uui-action-bar slot="actions">${this.#renderActions(item, index)}</uui-action-bar>
			</uui-card-media>
		`;
	}

	#renderActions(item: OEmbedPickerValue, index:number) {
		if (this.readonly) return nothing;
    return html`
      <uui-button label=${this.localize.term('general_edit')} look="secondary" @click=${() => this.#onEdit(index)}>
        <uui-icon name="icon-edit"></uui-icon>
      </uui-button>
			<uui-button label=${this.localize.term('general_remove')} look="secondary" @click=${() => this.#onRemove(index)}>
				<uui-icon name="icon-trash"></uui-icon>
			</uui-button>     
		`;
	}

	static override styles = [
		css`
			:host {
				position: relative;
			}
			.container {
				display: grid;
				grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
				gap: var(--uui-size-space-5);
			}

			#btn-add {
				text-align: center;
				height: 100%;
				aspect-ratio: 16/9;
			}

			uui-icon {
				display: block;
				margin: 0 auto;
			}

			uui-card-media umb-icon {
				font-size: var(--uui-size-8);
			}

			uui-card-media[drag-placeholder] {
				opacity: 0.2;
			}
			img {
				background-image: url('data:image/svg+xml;charset=utf-8,<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" fill-opacity=".1"><path d="M50 0h50v50H50zM0 50h50v50H0z"/></svg>');
				background-size: 10px 10px;
				background-repeat: repeat;
			}

			.preview-item{

				aspect-ratio: 16/9;
			}

			.preview-item iframe{
				width: 100%;
				height: 100%;
				pointer-events: none;
			}
		`,
	];
}

export { DawoeInputOmbedElement as element };

declare global {
	interface HTMLElementTagNameMap {
		[elementName]: DawoeInputOmbedElement;
	}
}
