<script lang="ts">
	export let value: number | undefined;
	export let min: number | undefined = undefined;
	export let max: number | undefined = undefined;
	export let hidden = false;
</script>

<label {hidden}>
	<slot />
	<input type="number" bind:value {min} {max} {hidden} />
</label>
