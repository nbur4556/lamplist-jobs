<script lang="ts">
	export let value: string | undefined;
	export let name = 'name';
	export let hidden = false;
</script>

<div class="form-control">
	<label class="label label-text" for={name} {hidden}><slot /></label>
	<input class="input input-bordered" {name} type="text" bind:value {hidden} />
</div>
