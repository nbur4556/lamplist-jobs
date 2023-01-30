<script lang="ts">
	export let value: string | undefined;
	export let hidden = false;
</script>

<label {hidden}>
	<slot />
	<input type="text" bind:value {hidden} />
</label>
