<script>
    import Modal from '../../UI/Modal.svelte';
    import Button from '../../UI/Button.svelte';
    import { createEventDispatcher } from 'svelte';

    export let showDialog;
    let loginForm;

    const dispatch = createEventDispatcher();
    let submitHandler = () => {
        dispatch('confirm', loginForm);
        showDialog = false;
    };

    let cancelHandler = () => {
        showDialog = false;
    };
</script>

<Modal bind:isVisible={showDialog}>
    <div>
        <form bind:this={loginForm}>
            <label for="username"> E-mail </label>
            <input type="text" name="username" id="username" />
            <label for="password"> Пароль </label>
            <input type="password" name="password" id="password" />
        </form>
    </div>
    <Button class="primary medium" on:click={submitHandler}>Войти</Button>
    <Button class="secondary medium" on:click={cancelHandler}>Отмена</Button>
</Modal>

<style>
</style>
