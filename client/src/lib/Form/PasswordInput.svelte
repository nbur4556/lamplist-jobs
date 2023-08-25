<script lang="ts">
	export let value: string | undefined;
	export let hidden = false;
</script>

<div class="form-control">
	<label class="label label-text" {hidden}><slot /></label>
	<input type="password" class="input input-bordered" bind:value {hidden} />
</div>
