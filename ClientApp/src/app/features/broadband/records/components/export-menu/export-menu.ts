import {
  ChangeDetectionStrategy,
  Component, inject,
  output
} from '@angular/core';

import { BroadbandExportFormat } from '@app/features/broadband/models/broadband-export-format';
import {BroadbandApi} from '@app/core/api/broadband-api.service';
import {HttpResponse} from '@angular/common/http';
import {BroadbandStore} from '@broadband/state/broadband.store';

@Component({
  selector: 'app-export-menu',
  standalone: true,
  templateUrl: './export-menu.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExportMenu {
  readonly exportRequested = output<BroadbandExportFormat>();
  readonly broadbandStore = inject(BroadbandStore);

  private getFileName(
    response: HttpResponse<Blob>,
    fallback: string
  ): string {
    const contentDisposition = response.headers.get('content-disposition');

    if (!contentDisposition) {
      return fallback;
    }

    const match = /filename="?([^"]+)"?/.exec(contentDisposition);

    return match?.[1] ?? fallback;
  }

  export(format: BroadbandExportFormat): void {
    this.broadbandStore.export(format).subscribe(response => {
      if (!response.body) {
        return;
      }

      const url = URL.createObjectURL(response.body);

      const link = document.createElement('a');
      link.href = url;
      link.download = this.getFileName(response, `broadband.${format}`);

      link.click();

      URL.revokeObjectURL(url);
    });
  }
}
