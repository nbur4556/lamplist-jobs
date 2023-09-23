<script lang="ts">
	export let value: number | undefined;
	export let min: number | undefined = undefined;
	export let max: number | undefined = undefined;
	export let hidden = false;

	$: hiddenClass = hidden ? 'hidden' : '';
</script>

<div class={`form-control ${hiddenClass}`}>
	<label class="label label-text"><slot /></label>
	<input class="input input-bordered" type="number" bind:value {min} {max} />
</div>
