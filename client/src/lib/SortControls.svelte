<script lang="ts">
	import type { JobEntry } from '@src/store/JobListStore';

	export let sortBy: keyof JobEntry;
	export let sortIsReversed: boolean;
</script>

<label for="sort">
	Sort by
	<select name="sort" class="select select-xs" bind:value={sortBy}>
		<option value="company">Company</option>
		<option value="contact">Contact</option>
		<option value="interest">Interest</option>
		<option value="posting">Posting</option>
	</select>
</label>

<label for="reverse">
	Reverse
	<input
		name="reverse"
		type="checkbox"
		class="checkbox checkbox-xs"
		bind:checked={sortIsReversed}
	/>
</label>
