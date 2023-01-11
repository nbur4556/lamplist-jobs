<script lang="ts">
	export let value: string | undefined;
</script>

<label>
	<slot />
	<input type="text" bind:value />
</label>
