<script>
    import Modal from './Modal.svelte';
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
        console.log(respoce.json());
    };
</script>

<Modal>
    <button slot="trigger" class="btn">Войти</button>
    <p slot="header">Вход в аккаунт</p>
    <div slot="content">
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

<style>
    .btn {
        padding: 8px 16px;
        font-size: 14px;
        line-height: 16px;
        background-color: #f3f3f7;
        color: #5c6370;
        border-radius: 20px;
        border: medium none;
        cursor: pointer;
    }
</style>
