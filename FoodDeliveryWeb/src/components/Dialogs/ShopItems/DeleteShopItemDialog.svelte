<script lang="ts">
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';
    import type { ShopItem } from '../../../types';

    export let shopItem: ShopItem;
    export let showDialog: boolean;

    const dispatch = createEventDispatcher<{ confirm: number }>();

    let submitHandler = () => {
        dispatch('confirm', shopItem.id);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div class="shopItem">
        {JSON.stringify(shopItem, null, '\t')}
    </div>
    <Button class="primary medium" on:click={submitHandler}>Удалить</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
    .shopItem {
        padding: 10px;
        background-color: #f3f3f7;
        border-radius: 5px;
        white-space: pre-wrap;
        margin-bottom: 15px;
    }
</style>
