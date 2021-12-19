<script>
    let show = false;
</script>

<button
    on:click={() => {
        show = true;
    }}
    class="cart-btn">Корзина</button
>
{#if show}
    <div
        on:click={() => {
            show = false;
        }}
        class="cart-wrapper"
    />
{/if}
<div class:cart-active={show} class="cart">TODO</div>

<style>
    .cart-wrapper {
        position: fixed;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background-color: rgba(0, 0, 0, 0.712);
    }
    .cart-btn {
        height: 40px;
        padding: 8px 20px;
        font-size: 16px;
        line-height: 24px;
        background-color: rgb(232, 97, 0);
        color: rgb(255, 255, 255);
        border-radius: 20px;
        border: medium none;
        cursor: pointer;
    }
    .cart {
        transition: transform 0.5s ease-in-out;
        transform: translate(430px);
        position: fixed;
        right: 0;
        top: 0;
        bottom: 0;
        width: 430px;
        background: white;
    }
    .cart-active {
        transform: translate(0);
    }
</style>
