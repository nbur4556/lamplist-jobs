import { PUBLIC_API_URL } from '$env/static/public';

import type { StoreUpdater } from './types';

const deleteJobEntries = async (id: number, update: StoreUpdater) => {
	try {
		await fetch(`${PUBLIC_API_URL}/api/joblist/${id}`, {
			method: 'DELETE'
		});
		update((state) => state.filter((val, i) => i !== id));
	} catch (err) {
		console.error(err);
	}
};

export default deleteJobEntries;
