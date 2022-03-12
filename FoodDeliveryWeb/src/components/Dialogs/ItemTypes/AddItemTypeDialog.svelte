<script lang="ts">
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let showDialog: boolean;

    let itemTypeName: string = '';

    const dispatch = createEventDispatcher<{ confirm: string }>();

    let submitHandler = () => {
        dispatch('confirm', itemTypeName);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div>
        <label for="itemName"> Название </label>
        <input type="text" name="name" id="itemName" bind:value={itemTypeName} />
    </div>
    <Button class="primary medium" on:click={submitHandler}>Добавить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
