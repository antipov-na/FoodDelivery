<script>
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let showDialog;
    export let itemType;

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
        <span> Id:<br /> {itemType.id}</span>
        <label for="itemName"> Название </label>
        <input type="text" name="name" id="itemName" value={itemType.name} />
    </div>

    <Button class="primary medium" on:click={submitHandler}>Изменить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
