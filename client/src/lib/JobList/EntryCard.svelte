<script lang="ts">
	import type { JobEntry } from '@src/store/JobListStore';
	export let job: JobEntry;
	export let collapsed = false;
</script>

<section class="card w-full bg-primary">
	<div class="card-body">
		<div class="card-title justify-between">
			<h3>{job.company}</h3>
			<div class="card-actions">
				<slot name="actions" />
			</div>
		</div>

		{#if collapsed === false}
			<p>
				Contact: {#if job.contact}{job.contact}{/if}
			</p>
			<p>
				Interest: {#if job.interest}{job.interest}{/if}
			</p>
			<p>
				Posting: {#if job.posting}{job.posting}{/if}
			</p>
		{/if}
	</div>
</section>
