import { PUBLIC_API_URL } from '$env/static/public';

import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const fetchJobEntries = async (update: StoreUpdater<JobEntry[]>) => {
	try {
		const response = await (await fetch(`${PUBLIC_API_URL}/api/joblist`)).json();
		update(() => response);
	} catch (err) {
		console.error(err);
	}
};

export default fetchJobEntries;
