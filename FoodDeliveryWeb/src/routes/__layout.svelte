<script>
    import { itemTypes } from '../stores/apiDataProvider.js';
    import Header from '../components/Header.svelte';
    import StickyNav from '../components/StickyNav/StickyNav.svelte';
    import Footer from '../components/Footer.svelte';
</script>

<Header />
<main>
    <StickyNav itemTypes={$itemTypes} />
    <slot />
</main>
<Footer />

<style>
</style>
