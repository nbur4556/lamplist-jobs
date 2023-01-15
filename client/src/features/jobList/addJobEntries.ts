import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from './types';

const addJobEntries = async (entry: JobEntry, update: StoreUpdater) => {
	try {
		const result = await fetch('http://localhost:5000/api/joblist', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(entry)
		});
		const response = await result.json();
		update((state) => [...state, response]);
	} catch (err) {
		//TODO: Error Handling
		console.error(err);
	}
};

export default addJobEntries;
