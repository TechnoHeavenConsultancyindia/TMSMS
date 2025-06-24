import type { EntityDto } from '@abp/ng.core';

export interface AppFileDescriptorDto extends EntityDto<string> {
  name?: string;
  mimeType?: string;
}

export interface DownloadTokenResultDto {
  token?: string;
}

export interface GetFileInput {
  downloadToken?: string;
  fileId?: string;
}
