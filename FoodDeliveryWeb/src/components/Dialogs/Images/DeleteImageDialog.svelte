<script>
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let image;
    export let showDialog;

    const dispatch = createEventDispatcher();

    let submitHandler = () => {
        dispatch('confirm', image);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <img class="image" src={image.url} alt="" />
    <Button class="primary medium" on:click={submitHandler}>Удалить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
    img {
        margin: 0;
    }
    .image {
        display: block;
        padding: 10px;
        background-color: #f3f3f7;
        border-radius: 5px;
        margin-bottom: 15px;
        height: 200px;
    }
</style>
