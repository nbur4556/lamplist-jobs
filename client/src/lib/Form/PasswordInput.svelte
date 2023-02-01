<script lang="ts">
	export let value: string | undefined;
	export let hidden = false;
</script>

<label {hidden}>
	<slot />
	<input type="password" bind:value {hidden} />
</label>
