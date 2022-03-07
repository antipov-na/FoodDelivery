<script lang="ts">
    import sticky from './sticky';
</script>

<div class="sticky" on:stuck use:sticky={{ stickToTop: true }}>
    <slot />
</div>

<style>
    .sticky {
        display: var(--display, flex);
        position: sticky;
        justify-content: var(--justify-content, unset);
        align-items: var(--align-items, unset);
        top: 0;
        z-index: 1000;
        background-color: var(--background-color, unset);
    }
</style>
