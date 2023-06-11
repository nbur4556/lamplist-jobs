import { writable } from 'svelte/store';

import {
	addJobEntries,
	deleteJobEntries,
	fetchJobEntries,
	updateJobEntries
} from '@src/features/jobList';

// TODO id should be required when referring to a server JobEntry, and optional when referring to a client job entry
export interface JobEntry {
	id?: string;
	company: string;
	contact?: string;
	interest?: number;
	posting?: string;
}

const createJobListStore = () => {
	const { subscribe, update, set } = writable<Array<JobEntry>>([]);

	return {
		subscribe,
		fetchEntries: () => fetchJobEntries(update),
		updateEntry: (values: Partial<JobEntry>, id: string) => updateJobEntries(id, values, update),
		addEntry: (entry: JobEntry) => addJobEntries(entry, update),
		removeEntry: (id: string) => deleteJobEntries(id, update),
    emptyStore: () => set([]),
	};
};

export const JobListStore = createJobListStore();
