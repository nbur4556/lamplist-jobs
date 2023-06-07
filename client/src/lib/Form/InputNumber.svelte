<script lang="ts">
	export let value: number | undefined;
	export let min: number | undefined = undefined;
	export let max: number | undefined = undefined;
	export let hidden = false;
</script>

<div>
	<label {hidden}>
		<slot />
	</label>
	<input type="number" bind:value {min} {max} {hidden} />
</div>

<style>
	div {
		display: flex;
		flex-direction: row;
		justify-content: space-between;
	}
</style>
