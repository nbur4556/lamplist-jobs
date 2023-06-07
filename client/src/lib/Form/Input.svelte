<script lang="ts">
	export let value: string | undefined;
	export let hidden = false;
</script>

<div>
	<label {hidden}><slot /></label>
	<input type="text" bind:value {hidden} />
</div>

<style>
	div {
		display: flex;
		flex-direction: row;
		justify-content: space-between;
	}
</style>
