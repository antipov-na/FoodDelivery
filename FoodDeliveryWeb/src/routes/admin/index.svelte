<script>
    import { shopItems, itemTypes, images } from '../../stores/apiDataProvider.js';

    import AddDilog from '../../components/Dialogs/ShopItems/AddDilog.svelte';
    import EditDialog from '../../components/Dialogs/ShopItems/EditDialog.svelte';
    import DeleteDialog from '../../components/Dialogs/ShopItems/DeleteDialog.svelte';

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

    let promice1 = shopItems.get();
    let promice2 = itemTypes.get();
    let promice3 = images.get();

    let selectedShopItem;
    let selectedItemType;
    let selectedImage;

    let showEditShopItemModal;
    let showDeleteShopItemModal;
    let showAddShopItemModal;

    let showAddItemTypeModal;
    let showDeleteItemTypeModal;
    let showEditItemTypeModal;

    let showAddImageModal;
    let showDeleteImageModal;

    let currentTab = 0;

    let editShopItemDialogSubmitHandler = (event) => {
        shopItems.update(event.detail);
    };

    let deleteShopItemDialogSubmitHandler = (event) => {
        shopItems.delete(event.detail.id);
    };

    let addShopItemDialogSubmitHandler = (event) => {
        shopItems.add(event.detail);
    };

    let editItemTypeDialogSubmitHandler = (event) => {
        itemTypes.update(event.detail);
    };

    let deleteItemTypeDialogSubmitHandler = (event) => {
        itemTypes.delete(event.detail.id);
    };

    let addItemTypeDialogSubmitHandler = (event) => {
        itemTypes.add(event.detail);
    };

    let addImageDialogSubmitHandler = (event) => {
        images.add(event.detail);
    };

    let deleteImaeDialogSubmitHandler = (event) => {
        images.delete(event.detail.id);
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
        {#await promice1 then a}
            <ShopItemTable shopItems={$shopItems} bind:selectedItem={selectedShopItem} />
        {/await}
        {#if selectedShopItem}
            <EditDialog
                on:confirm={editShopItemDialogSubmitHandler}
                bind:showDialog={showEditShopItemModal}
                shopItem={selectedShopItem}
                images={$images}
                itemTypes={$itemTypes}
            />
            <DeleteDialog
                on:confirm={deleteShopItemDialogSubmitHandler}
                bind:showDialog={showDeleteShopItemModal}
                shopItem={selectedShopItem}
            />
            <AddDilog
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
        {#await promice2 then a}
            <ItemTypesTable shopItemsTypes={$itemTypes} bind:selectedItem={selectedItemType} />
        {/await}
        {#if selectedItemType}
            <AddItemTypeDialog on:confirm={addItemTypeDialogSubmitHandler} bind:showDialog={showAddItemTypeModal} />
            <DeleteItemTypeDialog
                on:confirm={deleteItemTypeDialogSubmitHandler}
                bind:showDialog={showDeleteItemTypeModal}
                itemType={selectedItemType}
            />
            <EditItemTypeDialog
                on:confirm={editItemTypeDialogSubmitHandler}
                bind:showDialog={showEditItemTypeModal}
                itemType={selectedItemType}
            />
        {/if}
    {/if}

    {#if currentTab == 2}
        <div class="button-row">
            <Button on:click={() => (showAddImageModal = true)} class="primary small">Добавить</Button>
            <Button on:click={() => (showDeleteImageModal = true)} class="primary small">Удалить</Button>
        </div>
        {#await promice3 then a}
            <ImagesTable images={$images} bind:selectedItem={selectedImage} />
        {/await}
        {#if selectedImage}
            <AddImageDialog on:confirm={addImageDialogSubmitHandler} bind:showDialog={showAddImageModal} />
            <DeleteImageDialog
                on:confirm={deleteImaeDialogSubmitHandler}
                bind:showDialog={showDeleteImageModal}
                image={selectedImage}
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
