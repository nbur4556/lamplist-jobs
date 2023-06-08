import { PUBLIC_API_URL } from '$env/static/public';

import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const deleteJobEntries = async (id: string, update: StoreUpdater<JobEntry[]>) => {
	try {
		await fetch(`${PUBLIC_API_URL}/api/joblist/${id}`, {
			method: 'DELETE'
		});
		update((state) => state.filter((val) => val.id !== id));
	} catch (err) {
		console.error(err);
	}
};

export default deleteJobEntries;
