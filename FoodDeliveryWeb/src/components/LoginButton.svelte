<script>
    import { onMount } from 'svelte';
    import Modal from '../components/UI/Modal.svelte';
    import { eraseCookie, getCookie, setCookie } from '../js/cookies.js';
    let userName = '';
    onMount(() => {
        userName = getCookie('userName');
    });

    let showLoginDialog;
    let login = async (e) => {
        let form = new FormData(e.target);
        const respoce = await fetch('https://localhost:44384/api/authentication/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                username: form.get('username'),
                password: form.get('password')
            })
        });
        if (respoce.ok) {
            let json = await respoce.json();
            setCookie('userName', json.userName, json.validTo);
            setCookie('token', json.token, json.validTo);
            userName = json.userName;
            loginDialog.close();
        } else {
            alert('Что-то пошло не так');
        }
    };
    let logout = () => {
        eraseCookie('userName');
        eraseCookie('token');
        userName = '';
    };
</script>

{#if userName == '' || userName == null}
    <button on:click={() => (showLoginDialog = true)} class="btn">Войти</button>
    <Modal bind:isVisible={showLoginDialog}>
        <p>Вход в аккаунт</p>
        <div>
            <form on:submit|preventDefault={login}>
                <label>
                    E-mail
                    <input type="text" name="username" id="username" />
                </label>
                <label>
                    Пароль
                    <input type="password" name="password" id="password" />
                </label>
                <button class="btn">Войти</button>
            </form>
        </div>
    </Modal>
{:else}
    <span class="user-name">
        {userName}
    </span>
    <button class="btn" on:click={logout}>Выйти</button>
{/if}

<style>
    .btn {
        margin: 0;
        padding: 8px 16px;
        font-size: 14px;
        line-height: 16px;
        background-color: #f3f3f7;
        color: #5c6370;
        border-radius: 20px;
        border: medium none;
        cursor: pointer;
    }

    .user-name {
        margin-right: 32px;
    }
</style>
