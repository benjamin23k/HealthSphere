import { apiClient } from "./apiClient";
import type { ApiResponse } from "../types/models";


export function createCrudService<TRead, TCreate, TUpdate>(resource: string) {
  return {
    getAll: async (): Promise<TRead[]> => {
      const res = await apiClient.get<ApiResponse<TRead[]>>(`/${resource}`);
      return res.data.data;
    },
    getById: async (id: number): Promise<TRead> => {
      const res = await apiClient.get<ApiResponse<TRead>>(`/${resource}/${id}`);
      return res.data.data;
    },
    create: async (dto: TCreate): Promise<TRead> => {
      const res = await apiClient.post<ApiResponse<TRead>>(`/${resource}`, dto);
      return res.data.data;
    },
    update: async (id: number, dto: TUpdate): Promise<void> => {
      await apiClient.put(`/${resource}/${id}`, dto);
    },
    remove: async (id: number): Promise<void> => {
      await apiClient.delete(`/${resource}/${id}`);
    },
  };
}
