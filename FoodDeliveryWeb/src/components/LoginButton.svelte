<script>
    import { onMount } from 'svelte';
    import LoginDialog from './Dialogs/Login/LoginDialog.svelte';
    import Button from './UI/Button.svelte';

    let userName;
    onMount(() => {
        userName = window.localStorage.getItem('userName');
    });

    let showLoginDialog = false;
    let loginDialogSubmitHandler = async (event) => {
        let formData = new FormData(event.detail);

        const response = await fetch('https://localhost:44384/api/authentication/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            credentials: 'include',
            body: JSON.stringify({
                username: formData.get('username'),
                password: formData.get('password')
            })
        });

        if (response.ok) {
            window.localStorage.setItem('userName', formData.get('username'));
            userName = formData.get('username');
        } else {
            console.log(response);
        }
    };

    let logOut = async () => {
        const response = await fetch('https://localhost:44384/api/authentication/logout', {
            method: 'POST',
            credentials: 'include'
        });
        if (response.ok) {
            window.localStorage.removeItem('userName');
            userName = '';
        } else {
            console.log(response);
        }
    };
</script>

{#if userName != '' && userName != null}
    {userName}
    <Button class="tertiary small" on:click={() => logOut()}>Выйти</Button>
{:else}
    <Button class="tertiary small" on:click={() => (showLoginDialog = true)}>Войти</Button>
    <LoginDialog on:confirm={loginDialogSubmitHandler} bind:showDialog={showLoginDialog} />
{/if}
