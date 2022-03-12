<script lang="ts">
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';
    import type { EditShopItemDto, Image, ItemType, ShopItem } from '../../../types';

    export let showDialog: boolean;
    export let shopItem: ShopItem;
    export let itemTypes: ItemType[];
    export let images: Image[];
    // $: _shopItem = JSON.parse(JSON.stringify(shopItem));
    // $: {
    //     console.log(shopItem);
    // }
    const dispatch = createEventDispatcher<{ confirm: EditShopItemDto }>();

    let submitHandler = () => {
        let shopItemDto: EditShopItemDto = {
            id: shopItem.id,
            name: shopItem.name,
            description: shopItem.description,
            type: shopItem.type.id,
            price: shopItem.price,
            image: shopItem.image.id
        };
        dispatch('confirm', shopItemDto);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div>
        <span> Id:<br /> {shopItem.id}</span>
        <label for="itemName"> Название </label>
        <input type="text" name="name" id="itemName" bind:value={shopItem.name} />
        <label for="itemDescription">Описание</label>
        <textarea name="deescription" id="itemDescription" cols="30" rows="10" bind:value={shopItem.description} />
        <label for="itemPrice">Цена</label>
        <input type="number" name="price" id="itemPrice" bind:value={shopItem.price} min="1" step="0.01" />
        <label for="itemType">Тип</label>
        <select name="type" id="itemType" bind:value={shopItem.type.id}>
            {#each itemTypes as type}
                <option value={type.id}>{type.name}</option>
            {/each}
        </select>
        <label for="itemImage">Изображение</label>
        <select name="image" id="itemImage" bind:value={shopItem.image.id}>
            {#each images as img}
                <option value={img.id}>{img.url}</option>
            {/each}
        </select>
    </div>

    <Button class="primary medium" on:click={submitHandler}>Изменить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
