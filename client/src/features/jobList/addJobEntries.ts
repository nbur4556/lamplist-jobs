import { PUBLIC_API_URL } from '$env/static/public';

import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const addJobEntries = async (entry: JobEntry, update: StoreUpdater<JobEntry[]>) => {
	try {
		const result = await fetch(`${PUBLIC_API_URL}/api/joblist`, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(entry)
		});
		const response = await result.json();
		update((state) => [...state, response]);
	} catch (err) {
		console.error(err);
	}
};

export default addJobEntries;
