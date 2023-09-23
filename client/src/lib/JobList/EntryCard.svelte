<script lang="ts">
	import type { JobEntry } from '@src/store/JobListStore';
	export let job: JobEntry;
</script>

<section class="card w-full bg-primary">
	<div class="card-body">
		<div class="card-title">
			<h3>{job.company}</h3>
		</div>

		<p>
			Contact: {#if job.contact}{job.contact}{/if}
		</p>
		<p>
			Interest: {#if job.interest}{job.interest}{/if}
		</p>
		<p>
			Posting: {#if job.posting}{job.posting}{/if}
		</p>

		<div class="card-actions justify-end">
			<slot name="actions" />
		</div>
	</div>
</section>
