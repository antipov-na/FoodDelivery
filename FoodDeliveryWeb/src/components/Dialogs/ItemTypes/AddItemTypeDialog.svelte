<script>
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let showDialog;

    let itemType = {
        name: ''
    };

    const dispatch = createEventDispatcher();

    let submitHandler = () => {
        dispatch('confirm', itemType);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div>
        <label for="itemName"> Название </label>
        <input type="text" name="name" id="itemName" bind:value={itemType.name} />
    </div>
    <Button class="primary medium" on:click={submitHandler}>Добавить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
