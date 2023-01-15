import { writable } from 'svelte/store';

import { addJobEntries, fetchJobEntries } from '@src/features/jobList';

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

	const updateEntry = (entryData: Partial<JobEntry>, index: number) => {
		update((state) => {
			state[index] = { ...state[index], ...entryData };
			return state;
		});
	};

	return {
		subscribe,
		fetchEntries: () => fetchJobEntries(update),
		updateEntry,
		addEntry: (entry: JobEntry) => addJobEntries(entry, update),
		removeEntry: (index: number) => update((state) => state.filter((val, i) => i !== index))
	};
};

export const JobListStore = createJobListStore();
