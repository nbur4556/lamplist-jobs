<script lang="ts">
	import type { JobEntry } from '@src/store/JobListStore';
	export let job: JobEntry;
	export let collapsed = false;

	const toggleCollapsed = () => (collapsed = !collapsed);
</script>

<section class="card w-full bg-primary">
	<div class="card-body">
		<div class="card-title justify-between">
			<h3>{job.company}</h3>
			<div class="card-actions">
				<slot name="actions" />
				<button class="btn btn-outline btn-xs" on:click={toggleCollapsed}>
					{#if !collapsed} - {:else} + {/if}
				</button>
			</div>
		</div>

		{#if !collapsed}
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
