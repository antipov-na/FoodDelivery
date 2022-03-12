<script lang="ts" context="module">
    export async function load({ fetch }) {
        const shopItems: Writable<ShopItem[]> = writable<ShopItem[]>(
            await (await fetch('https://localhost:44384/api/shopItems/')).json()
        );
        const itemTypes: Writable<ItemType[]> = writable<ItemType[]>(
            await (await fetch('https://localhost:44384/api/shopItemTypes/')).json()
        );
        const images: Writable<Image[]> = writable<Image[]>(
            await (await fetch('https://localhost:44384/api/images/')).json()
        );
        return {
            props: { shopItems, itemTypes, images }
        };
    }
</script>

<script lang="ts">
    import type { ShopItem, ItemType, Image, EditShopItemDto, CreateShopItemDto } from '../../types';
    import { writable, type Writable } from 'svelte/store';

    import AddShopItemDialog from '../../components/Dialogs/ShopItems/AddShopItemDialog.svelte';
    import EditShopItemDialog from '../../components/Dialogs/ShopItems/EditShopItemDialog.svelte';
    import DeleteShopItemDialog from '../../components/Dialogs/ShopItems/DeleteShopItemDialog.svelte';

    import AddItemTypeDialog from '../../components/Dialogs/ItemTypes/AddItemTypeDialog.svelte';
    import DeleteItemTypeDialog from '../../components/Dialogs/ItemTypes/DeleteItemTypeDialog.svelte';
    import EditItemTypeDialog from '../../components/Dialogs/ItemTypes/EditItemTypeDialog.svelte';

    import AddImageDialog from '../../components/Dialogs/Images/AddImageDialog.svelte';
    import DeleteImageDialog from '../../components/Dialogs/Images/DeleteImageDialog.svelte';

    import ShopItemTable from '../../components/UI/Tabels/ShopItemTable.svelte';
    import ItemTypesTable from '../../components/UI/Tabels/ItemTypesTable.svelte';
    import ImagesTable from '../../components/UI/Tabels/ImagesTable.svelte';

    import Button from '../../components/UI/Button.svelte';
    import RadioSlider from '../../components/UI/RadioSlider/RadioSlider.svelte';
    import RadioSliderButton from '../../components/UI/RadioSlider/RadioSliderButton.svelte';

    let selectedShopItem: ShopItem;
    let selectedItemType: ItemType;
    let selectedImage: Image;

    $: _selectedShopItem = selectedShopItem ? JSON.parse(JSON.stringify(selectedShopItem)) : null;
    $: _selectedItemType = selectedItemType ? JSON.parse(JSON.stringify(selectedItemType)) : null;
    $: _selectedImage = selectedImage ? JSON.parse(JSON.stringify(selectedImage)) : null;

    let showEditShopItemModal: boolean;
    let showDeleteShopItemModal: boolean;
    let showAddShopItemModal: boolean;

    let showAddItemTypeModal: boolean;
    let showDeleteItemTypeModal: boolean;
    let showEditItemTypeModal: boolean;

    let showAddImageModal: boolean;
    let showDeleteImageModal: boolean;

    let currentTab: number = 0;

    export let shopItems: Writable<ShopItem[]>;
    export let itemTypes: Writable<ItemType[]>;
    export let images: Writable<Image[]>;

    let addShopItemDialogSubmitHandler = async (event: CustomEvent<CreateShopItemDto>): Promise<void> => {
        let item: CreateShopItemDto = event.detail;

        let formData: FormData = new FormData();
        formData.append('name', item.name);
        formData.append('description', item.description);
        formData.append('typeId', String(item.type));
        formData.append('price', String(item.price));
        formData.append('imageId', item.image);

        const response: Response = await fetch('https://localhost:44384/api/shopItems', {
            method: 'POST',
            body: formData
        });
        if (response.ok) {
            let newItem = await response.json();
            shopItems.update((arr) => [...arr, newItem as ShopItem]);
        } else {
            console.log(response);
        }
    };

    let editShopItemDialogSubmitHandler = async (event: CustomEvent<EditShopItemDto>): Promise<void> => {
        let item: EditShopItemDto = event.detail;

        let formData: FormData = new FormData();
        formData.append('id', String(item.id));
        formData.append('name', item.name);
        formData.append('description', item.description);
        formData.append('typeId', String(item.type));
        formData.append('price', String(item.price));
        formData.append('imageId', item.image);

        const response: Response = await fetch('https://localhost:44384/api/shopItems/', {
            method: 'PUT',
            body: formData
        });

        if (response.ok) {
            let newItem: ShopItem = await response.json();
            shopItems.update((arr) =>
                arr.map((_item) => {
                    if (_item.id === newItem.id) return newItem;
                    return _item;
                })
            );
        } else {
            console.log(response);
        }
    };

    let deleteShopItemDialogSubmitHandler = async (event: CustomEvent<number>): Promise<void> => {
        let itemId: number = event.detail;

        const response: Response = await fetch(`https://localhost:44384/api/shopItems/${itemId}`, {
            method: 'DELETE'
        });
        if (response.ok) {
            shopItems.update((arr) => arr.filter((_item) => _item.id !== itemId));
        } else {
            console.log(response);
        }
    };

    let addItemTypeDialogSubmitHandler = async (event: CustomEvent<string>): Promise<void> => {
        let itemName: string = event.detail;

        let formData: FormData = new FormData();
        formData.append('name', itemName);

        const response: Response = await fetch('https://localhost:44384/api/shopItemTypes/', {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            let newItem = await response.json();
            itemTypes.update((arr) => [...arr, newItem as ItemType]);
        } else {
            console.log(response);
        }
    };

    let editItemTypeDialogSubmitHandler = async (event: CustomEvent<EditShopItemDto>): Promise<void> => {
        let item: EditShopItemDto = event.detail;

        let formData: FormData = new FormData();
        formData.append('id', String(item.id));
        formData.append('name', item.name);

        const response: Response = await fetch('https://localhost:44384/api/shopItemTypes', {
            method: 'PUT',
            body: formData
        });
        if (response.ok) {
            let newItem: ItemType = await response.json();
            itemTypes.update((arr) =>
                arr.map((_item) => {
                    if (_item.id === newItem.id) return newItem;
                    return _item;
                })
            );
        } else {
            console.log(response);
        }
    };

    let deleteItemTypeDialogSubmitHandler = async (event: CustomEvent<number>): Promise<void> => {
        let itemId: number = event.detail;

        const response: Response = await fetch(`https://localhost:44384/api/shopItemTypes/${itemId}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            itemTypes.update((arr) => arr.filter((_item) => _item.id !== itemId));
        } else {
            console.log(response);
        }
    };

    let addImageDialogSubmitHandler = async (event: CustomEvent<File>): Promise<void> => {
        let image: File = event.detail;
        let formData = new FormData();
        formData.append('image', image);

        const response = await fetch('https://localhost:44384/api/images', {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            let newImage = await response.json();
            images.update((arr) => [...arr, newImage as Image]);
        } else {
            console.log(response);
        }
    };

    let deleteImaeDialogSubmitHandler = async (event: CustomEvent<string>): Promise<void> => {
        let id: string = event.detail;

        const response = await fetch(`https://localhost:44384/api/images/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            images.update((arr) => arr.filter((_item) => _item.id !== id));
        } else {
            console.log(response);
        }
    };
</script>

<div class="container">
    <header>
        <RadioSlider bind:selectedValue={currentTab} width={500} height={30} seam={2}>
            <RadioSliderButton label="Товары" id="0" value="0" selected={true} />
            <RadioSliderButton label="Типы товаров" id="1" value="1" />
            <RadioSliderButton label="Изображения тваров" id="2" value="2" />
        </RadioSlider>
    </header>

    {#if currentTab == 0}
        <div class="button-row">
            <Button on:click={() => (showAddShopItemModal = true)} class="primary small">Добавить</Button>
            <Button on:click={() => (showDeleteShopItemModal = true)} class="primary small">Удалить</Button>
            <Button on:click={() => (showEditShopItemModal = true)} class="primary small">Изменить</Button>
        </div>

        <ShopItemTable shopItems={$shopItems} bind:selectedItem={selectedShopItem} />
        {#if _selectedShopItem}
            <EditShopItemDialog
                on:confirm={editShopItemDialogSubmitHandler}
                bind:showDialog={showEditShopItemModal}
                shopItem={_selectedShopItem}
                images={$images}
                itemTypes={$itemTypes}
            />
            <DeleteShopItemDialog
                on:confirm={deleteShopItemDialogSubmitHandler}
                bind:showDialog={showDeleteShopItemModal}
                shopItem={_selectedShopItem}
            />
            <AddShopItemDialog
                on:confirm={addShopItemDialogSubmitHandler}
                bind:showDialog={showAddShopItemModal}
                images={$images}
                itemTypes={$itemTypes}
            />
        {/if}
    {/if}
    {#if currentTab == 1}
        <div class="button-row">
            <Button on:click={() => (showAddItemTypeModal = true)} class="primary small">Добавить</Button>
            <Button on:click={() => (showDeleteItemTypeModal = true)} class="primary small">Удалить</Button>
            <Button on:click={() => (showEditItemTypeModal = true)} class="primary small">Изменить</Button>
        </div>

        <ItemTypesTable shopItemsTypes={$itemTypes} bind:selectedItem={selectedItemType} />

        {#if _selectedItemType}
            <AddItemTypeDialog on:confirm={addItemTypeDialogSubmitHandler} bind:showDialog={showAddItemTypeModal} />
            <DeleteItemTypeDialog
                on:confirm={deleteItemTypeDialogSubmitHandler}
                bind:showDialog={showDeleteItemTypeModal}
                itemType={_selectedItemType}
            />
            <EditItemTypeDialog
                on:confirm={editItemTypeDialogSubmitHandler}
                bind:showDialog={showEditItemTypeModal}
                itemType={_selectedItemType}
            />
        {/if}
    {/if}

    {#if currentTab == 2}
        <div class="button-row">
            <Button on:click={() => (showAddImageModal = true)} class="primary small">Добавить</Button>
            <Button on:click={() => (showDeleteImageModal = true)} class="primary small">Удалить</Button>
        </div>

        <ImagesTable images={$images} bind:selectedItem={selectedImage} />

        {#if selectedImage}
            <AddImageDialog on:confirm={addImageDialogSubmitHandler} bind:showDialog={showAddImageModal} />
            <DeleteImageDialog
                on:confirm={deleteImaeDialogSubmitHandler}
                bind:showDialog={showDeleteImageModal}
                image={_selectedImage}
            />
        {/if}
    {/if}
</div>

<style>
    header {
        display: flex;
        justify-content: center;
        padding: 10px 0;
    }
    .button-row {
        padding: 10px;
    }
</style>
