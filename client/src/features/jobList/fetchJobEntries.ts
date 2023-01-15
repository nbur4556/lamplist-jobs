import type { Updater } from 'svelte/store';

import type { JobEntry } from '@src/store/JobListStore';

type StoreUpdater = (updater: Updater<JobEntry[]>) => void;

const fetchJobEntries = async (update: StoreUpdater) => {
	try {
		//TODO: Use environment to handle server url
		const response = await (await fetch('http://localhost:5000/api/joblist')).json();
		update(() => response);
	} catch (err) {
		//TODO: Error Handling
		console.error(err);
	}
};

export default fetchJobEntries;
