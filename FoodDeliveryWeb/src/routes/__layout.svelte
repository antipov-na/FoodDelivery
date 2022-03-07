<script context="module" lang="ts">
    import type { ItemType } from '../types';
    export async function load({ fetch }) {
        const itemTypes: ItemType[] = await (await fetch('https://localhost:44384/api/shopItemTypes/')).json();
        return {
            props: { itemTypes }
        };
    }
</script>

<script lang="ts">
    import Header from '../components/Header.svelte';
    import Sticky from '../components/StickyNav/Sticky.svelte';
    import Footer from '../components/Footer.svelte';
    import NavBar from '../components/UI/NavBar.svelte';
    import CartButton from '../components/CartButton.svelte';

    export let itemTypes: ItemType[];
    let isStuck: boolean = false;

    let onStuckHandler = (e: CustomEvent): void => {
        isStuck = e.detail.isStuck;
    };
</script>

<Header />
<main>
    <Sticky on:stuck={onStuckHandler} --background-color="#fff">
        <div class:stuck={isStuck} class="container sticky-container">
            <img class:stuck={isStuck} class="logo" height="36px" width="36px" src="/img/dodo.svg" alt="" />
            <NavBar --gap="10px" --align-items="center">
                {#each itemTypes as type}
                    <a class="link" href="/#{type.name}">{type.name}</a>
                {/each}
                <a class="link" href="/about">О Нас</a>
            </NavBar>
            <CartButton />
        </div>
        <div class:stuck={isStuck} class="sticky-shadow" />
    </Sticky>
    <slot />
</main>
<Footer />

<style>
    .logo {
        position: absolute;
        top: 50%;
        transform: translateY(-50%);
        left: -36px;
        transition: left ease-in-out 0.5s;
    }

    .logo.stuck {
        left: 0px;
    }

    .sticky-container {
        position: relative;
        display: flex;
        height: 58px;
        padding: 0;
        overflow: hidden;
        align-items: center;
        justify-content: space-between;
        transition: padding ease-in-out 0.5s;
    }

    .sticky-container.stuck {
        padding-left: 40px;
    }

    .sticky-shadow {
        position: absolute;
        pointer-events: none;
        width: 100%;
        height: 100%;
    }

    .sticky-shadow.stuck {
        box-shadow: rgba(6, 5, 50, 0.1) 0px 4px 30px;
    }

    .link {
        color: black;
        font-weight: 500;
        font-size: 14px;
        padding: 22px 0;
    }

    .link:hover {
        color: orange;
    }
</style>
