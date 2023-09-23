<script lang="ts">
	export let value: string | undefined;
	export let hidden = false;

	$: hiddenClass = hidden ? 'hidden' : '';
</script>

<div class={`form-control ${hiddenClass}`}>
	<label class="label label-text"><slot /></label>
	<input class="input input-bordered" type="password" bind:value />
</div>
