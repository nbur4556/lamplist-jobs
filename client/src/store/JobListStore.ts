import { writable } from 'svelte/store';

import {
	addJobEntries,
	deleteJobEntries,
	fetchJobEntries,
	updateJobEntries
} from '@src/features/jobList';

export interface JobEntry {
	company: string;
	//TODO: Should be an array of contacts
	contact?: string;
	//TODO: Should be on a scale of 0 - 3
	interest?: number;
	posting?: string;
}

const createJobListStore = () => {
	const { subscribe, update } = writable<Array<JobEntry>>([]);

	return {
		subscribe,
		fetchEntries: () => fetchJobEntries(update),
		updateEntry: (entry: Partial<JobEntry>, id: number) => updateJobEntries(id, entry, update),
		addEntry: (entry: JobEntry) => addJobEntries(entry, update),
		removeEntry: (id: number) => deleteJobEntries(id, update)
	};
};

export const JobListStore = createJobListStore();
