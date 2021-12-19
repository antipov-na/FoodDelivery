<script>
    export let name = '';
</script>

<div>
    <h2 id={name}>{name}</h2>
    <slot />
</div>

<style>
    h2 {
        font-weight: 600;
    }
</style>
