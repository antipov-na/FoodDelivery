<script>
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let showDialog;
    export let shopItem;
    export let itemTypes;
    export let images;

    const dispatch = createEventDispatcher();

    let submitHandler = () => {
        dispatch('confirm', shopItem);
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
        <input type="text" name="name" id="itemName" value={shopItem.name} />
        <label for="itemDescription">Описание</label>
        <textarea name="deescription" id="itemDescription" cols="30" rows="10" value={shopItem.description} />
        <label for="itemPrice">Цена</label>
        <input type="number" name="price" id="itemPrice" value={shopItem.price} min="1" step="0.01" />
        <label for="itemType">Тип</label>
        <select name="type" id="itemType">
            {#each itemTypes as type}
                <option value={type.id}>{type.name}</option>
            {/each}
        </select>
        <label for="itemImage">Изображение</label>
        <select name="image" id="itemImage">
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
