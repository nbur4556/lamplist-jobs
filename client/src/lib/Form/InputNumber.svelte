<script lang="ts">
	export let value: number | undefined;
	export let min: number | undefined = undefined;
	export let max: number | undefined = undefined;
</script>

<label>
	<slot />
	<input type="number" bind:value {min} {max} />
</label>
