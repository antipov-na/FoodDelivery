<script lang="ts">
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';
    import type { Image, ItemType, CreateShopItemDto } from '../../../types';

    export let showDialog: boolean;
    export let itemTypes: ItemType[];
    export let images: Image[];
    let shopItemDto: CreateShopItemDto = {
        name: '',
        description: '',
        image: '',
        price: 0,
        type: 0
    };

    const dispatch = createEventDispatcher<{ confirm: CreateShopItemDto }>();

    let submitHandler = () => {
        dispatch('confirm', shopItemDto);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div>
        <label for="itemName"> Название </label>
        <input type="text" name="name" id="itemName" bind:value={shopItemDto.name} />
        <label for="itemDescription">Описание</label>
        <textarea name="deescription" id="itemDescription" cols="30" rows="10" bind:value={shopItemDto.description} />
        <label for="itemPrice">Цена</label>
        <input type="number" name="price" id="itemPrice" bind:value={shopItemDto.price} min="1" step="0.01" />
        <label for="itemType">Тип</label>
        <select bind:value={shopItemDto.type} name="type" id="itemType">
            {#each itemTypes as type}
                <option value={type.id}>{type.name}</option>
            {/each}
        </select>
        <label for="itemImage">Изображение</label>
        <select bind:value={shopItemDto.image} name="image" id="itemImage">
            {#each images as img}
                <option value={img.id}>{img.url}</option>
            {/each}
        </select>
    </div>
    <Button class="primary medium" on:click={submitHandler}>Добавить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
