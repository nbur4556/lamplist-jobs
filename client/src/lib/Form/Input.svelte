<script lang="ts">
	export let value: string | undefined;
	export let name = 'name';
	export let hidden = false;

	$: hiddenClass = hidden ? 'hidden' : '';
</script>

<div class={`form-control ${hiddenClass}`}>
	<label class="label label-text" for={name}><slot /></label>
	<input class="input input-bordered" {name} type="text" bind:value />
</div>
