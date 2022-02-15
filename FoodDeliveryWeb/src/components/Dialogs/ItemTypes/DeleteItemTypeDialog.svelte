<script>
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let itemType;
    export let showDialog;

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
    <div class="itemType">
        {JSON.stringify(itemType, null, '\t')}
    </div>
    <Button class="primary medium" on:click={submitHandler}>Удалить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
    .itemType {
        padding: 10px;
        background-color: #f3f3f7;
        border-radius: 5px;
        white-space: pre-wrap;
        margin-bottom: 15px;
    }
</style>
