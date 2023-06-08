import { PUBLIC_API_URL } from '$env/static/public';

import type { JobEntry } from '@src/store/JobListStore';

import type { StoreUpdater } from '../types';

const updateJobEntries = async (
	id: string,
	values: Partial<JobEntry>,
	update: StoreUpdater<JobEntry[]>
) => {
	try {
		const result = await fetch(`${PUBLIC_API_URL}/api/joblist/${id}`, {
			method: 'PATCH',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(values)
		});
		const response = await result.json();

		update((state) => {
			state.forEach((entry, index) => {
				if (entry.id === id) {
					state[index] = { ...entry, ...response };
				}
			});
			return state;
		});
	} catch (err) {
		console.error(err);
	}
};

export default updateJobEntries;
