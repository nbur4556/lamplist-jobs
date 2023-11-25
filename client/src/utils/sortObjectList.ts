//! Undefined values do not get sorted, should be at the end
//TODO: thoroughly test this function
const sortObjectList = <T>(list: Array<T>, term: keyof T, reversed: boolean): Array<T> => {
	type Val = T[typeof term];
	const checkComparison = (a: Val, b: Val, reversed: boolean) => {
		return reversed ? a > b : a < b;
	};

	let sortedList: Array<T> = [];
	list.forEach((enty) => {
		for (let i = 0; i < sortedList.length; i++) {
			if (checkComparison(enty[term], sortedList[i][term], reversed)) {
				sortedList = [...sortedList.slice(0, i), enty, ...sortedList.slice(i, sortedList.length)];
				return;
			}
		}
		sortedList = [...sortedList, enty];
	});
	return sortedList;
};

export default sortObjectList;
