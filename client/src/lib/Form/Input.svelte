<script lang="ts">
	export let value: string | undefined;
	export let hidden = false;
</script>

<div>
	<label {hidden}><slot /></label>
	<!-- Placed in another div to remove 3rd party plugin icons as flex children -->
	<div><input type="text" bind:value {hidden} /></div>
</div>

<style>
	div {
		display: flex;
		flex-direction: row;
		justify-content: space-between;
	}
</style>
