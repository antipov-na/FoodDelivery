<script lang="ts">
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let showDialog: boolean;
    let image: FileList;

    const dispatch = createEventDispatcher<{ confirm: File }>();

    let submitHandler = () => {
        dispatch('confirm', image[0]);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div>
        <label for="image"> Изображение </label>
        <input type="file" name="name" id="itemName" bind:files={image} />
    </div>
    <Button class="primary medium" on:click={submitHandler}>Добавить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
