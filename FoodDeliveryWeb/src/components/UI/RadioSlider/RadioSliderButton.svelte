<script>
    export let label = '';
    export let id = '';
    export let value = '';
    export let disabled = false;
    export let selected = false;
</script>

<label for={id} class:disabled>
    {label}
    <input type="radio" {selected} {id} {value} {disabled} />
</label>

<style>
    label {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100%;
        z-index: 100;
        cursor: pointer;
        flex: 1 1 0%;
    }
    .disabled {
        color: #abadba;
    }

    input {
        display: none;
    }
</style>
